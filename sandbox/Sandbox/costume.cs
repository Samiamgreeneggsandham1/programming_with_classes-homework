class Costume
{
    //attributes:
    public string headwear;

    public string gloves;

    public string shoes;

    public string upperGarment;

    public string lowerGarment;

    public string accessory;


    //behaviours

    public void ShowWardrobe()
    {
        string result = "";
        result += "Head gear: " + headwear;
        result += "Hand gear: " + gloves;
        result += "Foot gear: " + shoes;
        result += "Torso covering: " + upperGarment;
        result += "Leg covering: " + lowerGarment;
        result += "Accessory: " + accessory;
        Console.WriteLine(result);
    }
}