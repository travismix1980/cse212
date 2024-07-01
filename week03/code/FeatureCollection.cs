public class FeatureCollection
{
    // Todo Earthquake Problem - ADD YOUR CODE HERE
    // Create additional classes as necessary
    public string Type { get; set; }
    public Feature[] Features { get; set; }
}

public class Feature
{
    public Properties Properties { get; set; }
}

public class Properties
{
    public double Mag { get; set; }
    public string Place { get; set; }
}
