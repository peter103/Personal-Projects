import java.util.Random;

public class Airplane implements Comparable<Airplane>, Updatable
{
    //Main variable
    private int fuel = 0;

    Random randomNum = new Random();
    private String[] plane_model = {"Boeing 747", "Airbus A380", "Boeing 757","Boeing 767"};
    
    private String status = "ok";
    
    public Airplane(int fuel)
    {
        this.fuel = fuel;
    }
    @Override
    public void update()
    {
        fuel--;
    }
    
    public void updateStatus(String s)
    {
        status = s;
    }
    
    public int getFuel()
    {
        if(this.fuel < 0) // This will get rid of the negative value.
        {
            this.fuel = 0;
        }
        return this.fuel;
    }
    @Override
    public int compareTo(Airplane plane)
    {
        return (int)((this.fuel - plane.fuel)*100);
    }
    @Override
    public String toString()
    {
        return "Plane info: "+plane_model[randomNum.nextInt(plane_model.length)]+'\n'+
                "Fuel: "+fuel+" Units"+'\n'+"Plane Status: "+status+'\n';
    }
}
