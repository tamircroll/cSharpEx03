namespace GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

   public abstract class Vehicle
   {
       protected string m_Model;
       protected string m_PlateNumber;
       protected float m_EnergyLeft;
       protected List<Wheel> m_Wheels;

       public Vehicle(string i_Model, string i_Platenumber, float i_EnergyLeft, List<Wheel> i_Wheels)
       {
           m_Model = i_Model;
           m_PlateNumber = i_Platenumber;
           m_EnergyLeft = i_EnergyLeft;
           m_Wheels = i_Wheels;
       }

       public string Model
       {
           get { return m_Model; }
           set { m_Model = value; }
       }

       public string PlateNumber
       {
           get { return m_PlateNumber; }
           set { m_PlateNumber = value; }
       }

       public float EnergyLeft
       {
           get { return m_EnergyLeft; }
           set { m_EnergyLeft = value; }
       }

       public List<Wheel> Wheels
       {
           get { return m_Wheels; }
           set { m_Wheels = value; }
       }
   }
}
