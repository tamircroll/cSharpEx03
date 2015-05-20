using System.Collections.Generic;

namespace Ex03.GarageLogic.Vehicles
{
    using System;

     public class ElectricCar : Car
     {
         private const float k_MaxBattery = 2.2f;
         private readonly Electric r_ElectricEngine;

         public ElectricCar(string i_Model, string i_PlateNumber, eColor i_Color, eNumOfDoors i_NumOfDoors, float i_RemainBattery, List<Wheel> i_wheels)
             : base(i_Model, i_PlateNumber, i_Color, i_NumOfDoors, i_wheels)
         {
             r_ElectricEngine = new Electric(i_RemainBattery, k_MaxBattery);
         }

         public float RemainBattery()
         {
             return r_ElectricEngine.RemainBattery;
         }

         public float MaxBattery()
         {
             return r_ElectricEngine.MaxBattery;
         }

         public void ChargeBattery(float i_ToCharge)
         {
             r_ElectricEngine.ChargeBattery(i_ToCharge);
         }

         public override float PrecentOfEnergyLeft()
         {
             return RemainBattery()/MaxBattery();
         }

         protected override void SetIsElectric()
         {
             m_IsElectric = true;
         }

         public override string ToString()
         {
             return string.Format(
 @"{0}
{1}
",
 base.ToString(),
 
 r_ElectricEngine);
         }
     }
}