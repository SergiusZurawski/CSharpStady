﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CarLibrary
{
    public class MiniVan : Car
    {
        public MiniVan() { }
        public MiniVan(string name, int maxSp, int currSp) :
            base(name, maxSp, currSp)
        { }
        public override void TurboBoost()
        {
            engState = EngineState.engineDead;
            MessageBox.Show("");
        }
    }

    public class SportCar : Car
    {
        public SportCar() { }
        public SportCar(string name, int maxSp, int currSp) : 
            base(name, maxSp, currSp) { }
        public override void TurboBoost()
        {
            engState = EngineState.engineDead;
            MessageBox.Show("");
        }
    }
}
