/// <summary>
/// Interface for implementing manual product evaluation.
/// This interface defines the contract for any class that will evaluate products
/// based on their physical characteristics.
/// </summary>
public interface IManualIndicator
{
    /// <summary>
    /// Evaluates a product's authenticity based on its physical characteristics.
    /// </summary>
    /// <param name="characteristics">The physical characteristics of the product to evaluate</param>
    /// <returns>A detailed evaluation report including score and reasoning</returns>
    string EvaluateManual(PhysicalCharacteristics characteristics);
}