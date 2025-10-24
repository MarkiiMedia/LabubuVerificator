using System;
using System.Collections.Generic;

// Very small and explicit verifier for beginners.
// This file is self-contained and easy to read.
public static class SimpleVerifier
{
    private static readonly List<string> ValidCodes = new List<string> { "ABC123", "XYZ999" };

    public static bool SimpleVerifyCode(string code)
    {
        if (string.IsNullOrEmpty(code)) return false;

        // Prefer checking the SQLite DB if present/initialized.
        try
        {
            if (SimpleStorage.CodeExists(code)) return true;
        }
        catch
        {
            // If any DB error occurs, fall back to in-memory list (keeps behavior predictable for beginners)
        }

        // Fallback: simple in-memory lookup
        for (int i = 0; i < ValidCodes.Count; i++)
        {
            if (ValidCodes[i] == code) return true;
        }
        return false;
    }

    public static string SimpleEvaluateManual(int teethCount, int coloredTeethCount, bool eyesGlossy, string noseColor)
    {
        int score = 0;
        if (teethCount == 9) score += 3;
        if (coloredTeethCount == 0) score += 1;
        if (eyesGlossy) score += 1;
        if (!string.IsNullOrEmpty(noseColor))
        {
            var n = noseColor.ToLowerInvariant();
            if (n.Contains("brown") || n.Contains("red")) score += 1;
        }

        if (score >= 5) return "High";
        if (score >= 3) return "Medium";
        return "Low";
    }
}
