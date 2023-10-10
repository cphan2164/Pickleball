namespace Pickleball;


public class Players
{
    private string name;
    private float skill;
    private int idNum;
    public Players(string name, float skill, int idNum)
    {
        this.name = name;
        this.skill = skill;
        this.idNum = idNum;
    }

    public Players(string name, int idNum)
    {
        this.name = name;
        skill = 0;
        this.idNum = idNum;
    }

    public void setSkill(float skill)
    {
        this.skill = skill;
    }

    public void setName(string name)
    {
        this.name = name;
    }
    
    public float getSkill()
    {
        return skill;
    }

    public string getName()
    {
        return name;
    }

    public int getidNum()
    {
        return idNum;
    }
    
    
}