﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Verse;

namespace MoreAlerts
{
    abstract class Alert_MaybeCritical : Alert_Critical
    {

        private int lastActiveFrame = -1;

        public Alert_MaybeCritical()
        {
            this.defaultPriority = AlertPriority.Medium;
        }

        public override void AlertActiveUpdate()
        {

            /*
            if (this.defaultPriority == AlertPriority.Critical)
            {
                (this as Alert_Critical).AlertActiveUpdate();
            }
            else
            {
                (this as Alert).AlertActiveUpdate();
            }
            */

            if (this.defaultPriority == AlertPriority.Critical)
            {
                if (this.lastActiveFrame < Time.frameCount - 1)
                {
                    Messages.Message("MessageCriticalAlert".Translate(new object[]
                    {
                    this.GetLabel()
                    }), this.GetReport().culprit, MessageSound.SeriousAlert);
                }
                this.lastActiveFrame = Time.frameCount;
            }
            else
            {
                // Nothing.
            }

        }

        protected override Color BGColor
        {

            /*
            get
            {
                if (this.defaultPriority == AlertPriority.Critical)
                {
                    return (this as Alert_Critical).BGColor;
                }
                else
                {
                    return (this as Alert).BGColor;
                }
            }
            */

            get
            {
                if (this.defaultPriority == AlertPriority.Critical)
                {
                    float num = Pulser.PulseBrightness(0.5f, Pulser.PulseBrightness(0.5f, 0.6f));
                    return new Color(num, num, num) * Color.red;
                }
                else
                {
                    return Color.clear;
                }
            }

        }

    }
}
