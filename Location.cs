namespace Pickleball;

public class Location
{
    private string name;
    private string address;
    private string telephone;
    private List<string> mon = new List<string>();
    private List<string> tue = new List<string>();
    private List<string> wed = new List<string>();
    private List<string> thurs = new List<string>();
    private List<string> fri = new List<string>();
    private List<string> sat = new List<string>();
    private List<string> sun = new List<string>();
    private List<string>[] daysOfWeek;
    private int courts = 1;
    public Location(string name, string address, string telephone)
    {
        this.name = name;
        this.address = address;
        this.telephone = telephone;
        daysOfWeek = new List<string>[] {mon,tue,wed,thurs,fri,sat,sun };
    }

    public Location(string name, string address)
    {
        this.name = name;
        this.address = address;
        telephone = "";
        daysOfWeek = new List<string>[] {mon,tue,wed,thurs,fri,sat,sun };
    }

    public void updateName(string name)
    {
        this.name = name;
    }

    public void updateAdd(string address)
    {
        this.address = address;
    }

    public void updateTel(string telephone)
    {
        this.telephone = telephone;
    }

    public string getName()
    {
        return name;
    }
    
    public string getAddress()
    {
        return address;
    }
    
    public string getTelephone()
    {
        return telephone;
    }
    
    public void addHours(int day, string start, string end)
    {
        daysOfWeek[day].Add(start);
        daysOfWeek[day].Add(end);
    }

    public List<string>[] getHours()
    {
        return daysOfWeek;
    }

    public void addCourts(int numOfCourts)
    {
        courts = numOfCourts;
    }

    public int getCourts()
    {
        return courts;
    }

}