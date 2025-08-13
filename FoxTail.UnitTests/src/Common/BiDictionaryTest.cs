using FoxTail.Common.Collections;

namespace FoxTail.UnitTests.Common;

public class BiDictionaryTest
{
    [Test]
    public void TestBasic()
    {
        var biDict = new BiDictionary<int, string>
        {
            { 1, "One" },
            { 2, "Two" },
            { 3, "Three" },
        };

        // Check forward mapping
        Assert.That(biDict[1], Is.EqualTo("One"));
        Assert.That(biDict[2], Is.EqualTo("Two"));
        Assert.That(biDict[3], Is.EqualTo("Three"));

        // Check reverse mapping
        Assert.That(biDict["One"], Is.EqualTo(1));
        Assert.That(biDict["Two"], Is.EqualTo(2));
        Assert.That(biDict["Three"], Is.EqualTo(3));

        // Remove an entry
        biDict.Remove(2);
        Assert.Throws<KeyNotFoundException>(() => biDict.GetValue(2));
        Assert.Throws<KeyNotFoundException>(() => biDict.GetKey("Two"));
        
        // Clear the map
        biDict.Clear();
        Assert.Throws<KeyNotFoundException>(() => biDict.GetValue(1));
    }
    
    [Test]
    public void TestCapacity()
    {
        var biDict = new BiDictionary<int, string>(10);
        Assert.That(biDict, Is.Empty);

        // Add some entries
        biDict[1] = "One";
        biDict[2] = "Two";
        
        Assert.That(biDict, Has.Count.EqualTo(2));
        
        // Check if the capacity is respected
        Assert.DoesNotThrow(() => biDict[3] = "Three");
        
        Assert.That(biDict, Has.Count.EqualTo(3));
        Assert.That(biDict.Capacity, Is.GreaterThanOrEqualTo(10));

        biDict.EnsureCapacity(10);
        Assert.That(biDict.Capacity, Is.GreaterThanOrEqualTo(10));
    }
}