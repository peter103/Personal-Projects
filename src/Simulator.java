import java.util.Random;
public class Simulator 
{
    private static Random randomNum = new Random();
    
    private static int time = 1125; // 25 ticks 
    
    private static int sim_Probability = randomNum.nextInt((time%2)*3);
    
    private static int planeAmount = randomNum.nextInt(time/(sim_Probability+1));
    private static int planeFuel = randomNum.nextInt(time + 5);
    
    //private static int planeAmount = 5; // Debug
    //private static int planeFuel = 29; // Debug
    
    //These will store the landed and departed planes.
    private static LinkedList<Airplane> landed_planes = new LinkedList<>();
    private static LinkedList<Airplane> departed_planes = new LinkedList<>();
    
    //These are for planes that was crashed and failed to depart.
    private static LinkedList<Airplane> crashed_planes = new LinkedList<>();
    private static LinkedList<Airplane> failed_planes = new LinkedList<>();
    
    //Keep track of time in a list.
    private static LinkedList<Integer> sim_landTime = new LinkedList<>(); // List of landing time.
    private static LinkedList<Integer> sim_departTime = new LinkedList<>(); //List of departing time

    private static int total_landTime = 0; 
    private static int total_departTime = 0;
    
    //Tracks the value of how many planes landed. 
    private static int planes_landed = 0; // Amount of planes landed
    private static int planes_departed = 0; // Amounts of planes took off
    private static int planes_crashed = 0; // Amounts of planes that was crashed
    private static int planes_failed = 0; // Amount of planes failed to depart
    
    private static PriorityQueue<Airplane> airplanes = new PriorityQueue<>();
    
    private static boolean delay_flights = false;
    
    public static void main(String[] args) 
    {
        
        SpawnPlanes(Math.abs(deltaPlane()), Math.abs(planeFuel), airplanes);
        for(int i = 0; i < time; i++)
        {
            airplanes.updateValues();
            Manage(i,randomNum,airplanes,landed_planes,departed_planes);
        }
        System.out.println("--------------------------------");
        System.out.println("\n[Planes Landed] \n" + "Amount: " + planes_landed + "\n" + landed_planes);
        System.out.println("--------------------------------");
        System.out.println("\n[Planes Departed] \n"+ "Amount: " + planes_departed + "\n" + departed_planes);
        System.out.println("--------------------------------");
        System.out.println("\n[Planes Crashed] \nAmount: " + planes_crashed + "\n" + crashed_planes);
        System.out.println("--------------------------------");
        System.out.println("\n[Planes Failed To Depart] \nAmount: " + planes_failed + "\n" + failed_planes);
        System.out.println("--------------------------------");
        
        
        System.out.println("Average Departing Time: "+findAverage(total_departTime,sim_departTime.getAmountEntries()) + " Units\n");
        System.out.println("Longest Derparting Time: "+ getValues(sim_departTime) + " Units\n");
        System.out.println("Average Landing Time: "+ findAverage(total_landTime,sim_landTime.getAmountEntries())+" Units\n");
        System.out.println("Longest Landing Time: "+ getValues(sim_landTime) +" Units\n");
        System.out.println("Total Planes Departed: "+planes_departed+'\n');
        System.out.println("Total Planes Landed: "+planes_landed+'\n');
        System.out.println("Total Planes Crashed: "+planes_crashed+'\n');
        System.out.println("Total Planes Failed To Depart: "+planes_failed+'\n');
        System.out.println("Total Planes Departed and Landed: "+(planes_departed+planes_landed));
        System.out.println("Weather Condition: "+Weather());
        System.out.println("--------------------------------");
        System.out.println("Airport Message: "+AirportStatus()+'\n');
    }
    
    public static int deltaPlane() // This will generate a random amount of planes. 
    {
        return Math.abs(randomNum.nextInt(Math.abs(planeAmount)));
    }
    public static int getValues(LinkedList<Integer> list)
    {
        if(list.getFirstValue() != null)
        {
            return list.getFirstValue();
        }
        else
        {
            return 0;
        }
    }
    public static int findAverage(int total, int amount)
    {
        return Math.abs(total / (amount+1));
    }
    
    public static int deltaWait() // This will generate a random wait time value.
    {
        return randomNum.nextInt((planeFuel/2) + 2);
    }
    
    public static void SpawnPlanes(int amount,int fuel, PriorityQueue<Airplane> list)
    {
        for(int x = 1; x <= planeAmount + 1; x++)
        {
            fuel = randomNum.nextInt(time + 1);
            list.add(new Airplane(fuel));
        }
    }
    
    public static void Land(Airplane plane ,LinkedList<Airplane> landedPlane)
    {
        landedPlane.add(plane);
    }
    
    public static void Depart(Airplane plane, LinkedList<Airplane> departedPlane)
    {
        departedPlane.add(plane);
    }
    public static String Weather()
    {
        if(planes_failed >= 1 && planes_crashed >= 1)
        {
            delay_flights = true;
            return "Thunderstorm"; 
        }
        else if(planeAmount > 60 && planes_crashed >= 25)
        {
            return "Stormy"; 
        }
        return "Clear Sky";
    }
    
    public static String AirportStatus()
    {
        if(delay_flights && planes_departed == 0 && planes_landed == 0)
        {
            return "\nCritical Weather Condition. \nMost flights will be canceled. \nThank you for choosing Chaos Airlines.";
        }
        else if(delay_flights && planes_departed == 0 && planes_landed == 0 && planes_crashed < 10)
        {
            return "Airport Temporary Shutdown.";
        }
        else
        {
            return "Thank you for choosing Chaos Airlines!";
        }
    }
    
    //Note to self: Further adjust this one. Maybe it's better for airplane by itself.
    //Speculation: Requires time in this method. 
    public static void Manage(int time,Random chance,PriorityQueue<Airplane> list, LinkedList<Airplane> landedPlane, LinkedList<Airplane> departedPlane)
    {
        int c_result = chance.nextInt(100) + 1;
        
        int waitTime = deltaWait();
        
        // 50/50 chance of landing or departing.
        if(!list.isEmpty())
        {
            if(c_result >= 50)
            {   
                if (list.peek().getFuel() >= 2) // Takes 2 units to land. 
                {
                    landedPlane.add(list.remove());
                    total_landTime = total_landTime + (time+1);
                    sim_landTime.add(time+1); //Time landed 
                    planes_landed++;
                } 
                else if(c_result <= 12)
                {
                    list.peek().updateStatus("Turbine Failure");
                    crashed_planes.add(list.remove()); // Added the crashed planes to the list.
                    planes_crashed++;
                }
                else if(c_result >= 45 && c_result <= 59)
                {
                    list.peek().updateStatus("Damaged Wings");
                    crashed_planes.add(list.remove()); // Adding the failed planes to the list.
                    planes_crashed++;
                }
                else if(c_result < 75 && c_result >= 60)
                {
                    list.peek().updateStatus("Fuel Leakage");
                    crashed_planes.add(list.remove()); // Added the crashed planes to the list.
                    planes_crashed++;
                }
            }
            else if(c_result <= 10) // ill Passenger
            {
                if(list.peek().getFuel() > 0)
                {
                    list.peek().updateStatus("Medical Condition");
                    failed_planes.add(list.remove());
                    planes_failed++;
                }
            }
            else if(c_result >= 30 && c_result < 60)
            {
                if(list.peek().getFuel() > 0)
                {
                    list.peek().updateStatus("Engine Failure");
                    failed_planes.add(list.remove());
                    planes_failed++;
                }
            }
            else
            {
                if(list.peek().getFuel() >= 3) // Takes 3 units to depart.
                {
                    departedPlane.add(list.remove());
                    total_departTime = total_departTime + (time+1);
                    sim_departTime.add(time+1);
                    planes_departed++;
                }
                else if(c_result == 15)
                {
                    list.peek().updateStatus("Fuel Leakage");
                    failed_planes.add(list.remove()); // Adding the failed planes to the list.
                    planes_failed++;
                }
            }
        }
    }
}
