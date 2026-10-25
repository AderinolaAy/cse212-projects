public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
    // Step 1: Create an array with the required length.
    // Step 2: Loop through each position in the array.
    // Step 3: Calculate the multiple using number * (index + 1).
    // Step 4: Store the result in the array.
    // Step 5: Return the completed array.

    double[] result = new double[length];

    for (int i = 0; i < length; i++)
{
    result[i] = number * (i + 1);
}

return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
       // Step 1: Repeat the rotation process the number of times specified by amount.
// Step 2: Save the last value in the list.
// Step 3: Remove the last value from the end of the list.
// Step 4: Insert the saved value at the beginning of the list.
// Step 5: Continue until the list has been rotated the required amount.

for (int i = 0; i < amount; i++)
{
    // Save the last value
    int lastValue = data[data.Count - 1];

    // Remove the last value
    data.RemoveAt(data.Count - 1);

    // Insert it at the beginning
    data.Insert(0, lastValue);
}

    }
}
