using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace supershop
{
    class CashdrawerLibrary
    {
        public static byte[] getCode(string PrinterName)
        {
            byte[] DrawerOpen = new byte[] { };

            if (PrinterName.Contains("CBM-210")) { DrawerOpen = new byte[] { 7 }; }
            else if (PrinterName.Contains("150")) { DrawerOpen = new byte[] { 27, 120, 1 }; }
            else if (PrinterName.Contains("280")) { DrawerOpen = new byte[] { 27, 112, 0, 250, 250 }; }
            else if (PrinterName.Contains("3200 SERIES")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("4200")) { DrawerOpen = new byte[] { 7 }; }
            else if (PrinterName.Contains("4610")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("4610")) { DrawerOpen = new byte[] { 7 }; }
            else if (PrinterName.Contains("7167")) { DrawerOpen = new byte[] { 27, 112, 0, 55 }; }
            else if (PrinterName.Contains("7179")) { DrawerOpen = new byte[] { 27, 112, 0, 55 }; }
            else if (PrinterName.Contains("7197")) { DrawerOpen = new byte[] { 27, 112, 0, 55 }; }
            else if (PrinterName.Contains("7223")) { DrawerOpen = new byte[] { 27, 112, 80, 25, 250 }; }
            else if (PrinterName.Contains("80 PLUS")) { DrawerOpen = new byte[] { 27, 120, 1 }; }
            else if (PrinterName.Contains("A715")) { DrawerOpen = new byte[] { 27, 112, 0, 48, 251 }; }
            else if (PrinterName.Contains("A776")) { DrawerOpen = new byte[] { 27, 112, 1, 49, 251 }; }
            else if (PrinterName.Contains("A794")) { DrawerOpen = new byte[] { 27, 112, 1, 49, 251 }; }
            else if (PrinterName.Contains("A798")) { DrawerOpen = new byte[] { 27, 112, 0, 8, 8 }; }
            else if (PrinterName.Contains("A799")) { DrawerOpen = new byte[] { 27, 112, 0, 8, 8 }; }
            else if (PrinterName.Contains("A799-C40W")) { DrawerOpen = new byte[] { 27, 112, 0, 8, 8 }; }
            else if (PrinterName.Contains("AB-88A")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("AB-88H")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("ADP 300")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("AURA 5600")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("AURA 8000")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("BSC-10")) { DrawerOpen = new byte[] { 27, 110, 0, 48 }; }
            else if (PrinterName.Contains("BTP-2002NP")) { DrawerOpen = new byte[] { 27, 112, 48, 40, 200 }; }
            else if (PrinterName.Contains("BTP-M280")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("BTP-R880NP")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("CBM-1000")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("CBM-220")) { DrawerOpen = new byte[] { 7 }; }
            else if (PrinterName.Contains("CBM-230")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("CBM-231")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("CBM-232")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("CBM-233")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("CBM-253")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("CBM-262")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("CR 4200")) { DrawerOpen = new byte[] { 27, 112, 80, 25, 250 }; }
            else if (PrinterName.Contains("CT-S2000")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("CT-S300")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("DP7645III")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("dp-8340fm")) { DrawerOpen = new byte[] { 27, 7, 11, 55, 7 }; }
            else if (PrinterName.Contains("DRJST-51")) { DrawerOpen = new byte[] { 27, 112, 0, 100, 250 }; }
            else if (PrinterName.Contains("DS-800")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("E-801")) { DrawerOpen = new byte[] { 27, 112, 0, 25 }; }
            else if (PrinterName.Contains("ECP-500")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("EC-PM-520")) { DrawerOpen = new byte[] { 27, 112, 0, 40, 168 }; }
            else if (PrinterName.Contains("EC-PM-5890X")) { DrawerOpen = new byte[] { 7 }; }
            else if (PrinterName.Contains("EC-PM-80330")) { DrawerOpen = new byte[] { 27, 112, 0, 40, 168 }; }
            else if (PrinterName.Contains("EF4272")) { DrawerOpen = new byte[] { 27, 112, 0, 100, 250 }; }
            else if (PrinterName.Contains("ESC-POS")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("EVO-RP1")) { DrawerOpen = new byte[] { 27, 112, 0, 25 }; }
            else if (PrinterName.Contains("F100")) { DrawerOpen = new byte[] { 27, 112, 49, 48, 48 }; }
            else if (PrinterName.Contains("fp-350")) { DrawerOpen = new byte[] { 27, 112, 0, 48, 251 }; }
            else if (PrinterName.Contains("fp-410")) { DrawerOpen = new byte[] { 27, 112, 1, 49, 251 }; }
            else if (PrinterName.Contains("GP-5890")) { DrawerOpen = new byte[] { 27, 112, 0, 100, 250 }; }
            else if (PrinterName.Contains("GP-80160")) { DrawerOpen = new byte[] { 27, 112, 0, 100, 250 }; }
            else if (PrinterName.Contains("GP-U80300ii")) { DrawerOpen = new byte[] { 27, 112, 48, 32, 64 }; }
            else if (PrinterName.Contains("iDP-3210")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("iDP-3240")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("iDP-3310")) { DrawerOpen = new byte[] { 7, 27 }; }
            else if (PrinterName.Contains("iDP-3410")) { DrawerOpen = new byte[] { 7, 27 }; }
            else if (PrinterName.Contains("iDP-3420")) { DrawerOpen = new byte[] { 7, 27 }; }
            else if (PrinterName.Contains("iDP-3421")) { DrawerOpen = new byte[] { 7, 27 }; }
            else if (PrinterName.Contains("iDP-3423")) { DrawerOpen = new byte[] { 7, 27 }; }
            else if (PrinterName.Contains("iDP-3530")) { DrawerOpen = new byte[] { 7, 27 }; }
            else if (PrinterName.Contains("iDP-3535")) { DrawerOpen = new byte[] { 7, 27 }; }
            else if (PrinterName.Contains("iDP-3540")) { DrawerOpen = new byte[] { 7, 27 }; }
            else if (PrinterName.Contains("iDP-3541")) { DrawerOpen = new byte[] { 7, 27 }; }
            else if (PrinterName.Contains("iDP-3545")) { DrawerOpen = new byte[] { 7, 27 }; }
            else if (PrinterName.Contains("iDP-3546")) { DrawerOpen = new byte[] { 7, 27 }; }
            else if (PrinterName.Contains("iDP-3550")) { DrawerOpen = new byte[] { 7, 27 }; }
            else if (PrinterName.Contains("iDP-3551")) { DrawerOpen = new byte[] { 7, 27 }; }
            else if (PrinterName.Contains("iDP-460")) { DrawerOpen = new byte[] { 7 }; }
            else if (PrinterName.Contains("iTherm 280")) { DrawerOpen = new byte[] { 27, 120, 1 }; }
            else if (PrinterName.Contains("LK-TL-322")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("LPT005")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("LR2000")) { DrawerOpen = new byte[] { 27, 118, 140 }; }
            else if (PrinterName.Contains("LX-300+")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("M115A")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("M129C")) { DrawerOpen = new byte[] { 27, 112, 0, 64, 240 }; }
            else if (PrinterName.Contains("M188A")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("M188B")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("M188D")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("M192C")) { DrawerOpen = new byte[] { 27, 112, 0, 64, 240 }; }
            else if (PrinterName.Contains("M192H")) { DrawerOpen = new byte[] { 27, 112, 0, 64, 240 }; }
            else if (PrinterName.Contains("M-244A")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("M253A")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("M267D")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("M51PD")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("M665A")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("MJ-8250")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("MP-250TH")) { DrawerOpen = new byte[] { 27, 118, 140 }; }
            else if (PrinterName.Contains("M-T60")) { DrawerOpen = new byte[] { 27, 112, 32, 25 }; }
            else if (PrinterName.Contains("OKIPOS 1000")) { DrawerOpen = new byte[] { 27, 120, 1 }; }
            else if (PrinterName.Contains("OKIPOS 407")) { DrawerOpen = new byte[] { 7 }; }
            else if (PrinterName.Contains("ORP-800")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("P58B")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("P80")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("PcOS 50")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("PcOS 51")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("PcOS 52")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("PO6-L")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("PO6-S")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("PO6-U")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("POS 8350")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("POS-58")) { DrawerOpen = new byte[] { 27, 112, 0, 150, 250 }; }
            else if (PrinterName.Contains("POS58")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 125 }; }
            else if (PrinterName.Contains("POS-8350")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("POSjet 1000")) { DrawerOpen = new byte[] { 27, 120, 1 }; }
            else if (PrinterName.Contains("POSjet")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("PP6000")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("PP6900")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("PP7000")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("PP8000")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("PR-85")) { DrawerOpen = new byte[] { 27, 112, 0, 100, 100 }; }
            else if (PrinterName.Contains("PRP076")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("PRP-085iiiT")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("PRP300")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("PRT-100")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("PT3")) { DrawerOpen = new byte[] { 27, 112, 0, 25 }; }
            else if (PrinterName.Contains("PX700")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("Q3")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("RKP300")) { DrawerOpen = new byte[] { 27, 112, 0, 100, 250 }; }
            else if (PrinterName.Contains("RP 80")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("RP-3200")) { DrawerOpen = new byte[] { 27, 112, 0, 100, 250 }; }
            else if (PrinterName.Contains("RP-B10")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("RP-E10")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("RPP 325")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("RTP-3280")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("SC9-5870")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("SERIES 90")) { DrawerOpen = new byte[] { 27, 120, 1 }; }
            else if (PrinterName.Contains("SERIES 94")) { DrawerOpen = new byte[] { 27, 120, 1 }; }
            else if (PrinterName.Contains("SLK-TL322")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("SMART 300")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("SP2000")) { DrawerOpen = new byte[] { 27, 122, 49, 7 }; }
            else if (PrinterName.Contains("SP200-2")) { DrawerOpen = new byte[] { 27, 7, 11, 55, 7 }; }
            else if (PrinterName.Contains("SP200")) { DrawerOpen = new byte[] { 27, 7, 11, 55, 7 }; }
            else if (PrinterName.Contains("SP212")) { DrawerOpen = new byte[] { 27, 7, 11, 55, 7 }; }
            else if (PrinterName.Contains("SP500")) { DrawerOpen = new byte[] { 27, 122, 49, 7 }; }
            else if (PrinterName.Contains("SP512")) { DrawerOpen = new byte[] { 27, 122, 49, 7 }; }
            else if (PrinterName.Contains("SP550II")) { DrawerOpen = new byte[] { 27, 7, 10, 50, 7 }; }
            else if (PrinterName.Contains("SP-POS88VI")) { DrawerOpen = new byte[] { 27, 112, 48, 32, 64 }; }
            else if (PrinterName.Contains("SRP 220")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("SRP 270A")) { DrawerOpen = new byte[] { 27, 112, 0, 64, 240 }; }
            else if (PrinterName.Contains("SRP 270")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("SRP 275")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("SRP 350T")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("SRP 350")) { DrawerOpen = new byte[] { 27, 110, 0, 25, 250 }; }
            else if (PrinterName.Contains("SRP-150UG")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("SRP-275AP")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("SRP-275C")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("SRP-275")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("SRP-280")) { DrawerOpen = new byte[] { 27, 112, 0, 64, 240 }; }
            else if (PrinterName.Contains("SRP-330")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 255 }; }
            else if (PrinterName.Contains("SRP-350ii")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("SRP-350PLUSiii")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("SRP-350")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("SRP-375P")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("STP 131")) { DrawerOpen = new byte[] { 27, 112, 0, 48, 50 }; }
            else if (PrinterName.Contains("Sure POS")) { DrawerOpen = new byte[] { 27, 112, 0, 250, 250 }; }
            else if (PrinterName.Contains("SUREPOS500")) { DrawerOpen = new byte[] { 27, 112, 0, 250, 250 }; }
            else if (PrinterName.Contains("SX2100")) { DrawerOpen = new byte[] { 27, 112, 32, 55, 255 }; }
            else if (PrinterName.Contains("T1")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("T200")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("T3")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("T-300")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("T88iiiP")) { DrawerOpen = new byte[] { 27, 112, 0, 64, 240 }; }
            else if (PrinterName.Contains("T88iii")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TH-230")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("TM-200")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-220")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-300D")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-82")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 251 }; }
            else if (PrinterName.Contains("TM-82ii")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 251 }; }
            else if (PrinterName.Contains("TM-88IV")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("TM-88V")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("TM-90")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-H5000II")) { DrawerOpen = new byte[] { 27, 113, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-H6000")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("TM-H6000ii")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("TM-J7100")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("TM-L60II")) { DrawerOpen = new byte[] { 27, 70, 0, 50, 50 }; }
            else if (PrinterName.Contains("TM-T20")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("TM-T70")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("TM-T80P")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-T81")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-T85")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-T88")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-T883P")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("TM-T88II")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-T88IIP")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("TM-U200B")) { DrawerOpen = new byte[] { 27, 112, 48, 25, 250 }; }
            else if (PrinterName.Contains("TM-U200D")) { DrawerOpen = new byte[] { 27, 112, 0, 64, 240 }; }
            else if (PrinterName.Contains("TM-U210D")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-U210PD")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-U220")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-U220A")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-U220B")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-U220D")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-U220PD")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-U295")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("TM-U300PC")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-U300PD")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-U325D")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-U375")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("TM-U950P")) { DrawerOpen = new byte[] { 27, 112, 0, 50, 250 }; }
            else if (PrinterName.Contains("TP610C")) { DrawerOpen = new byte[] { 27, 112, 0, 100, 250 }; }
            else if (PrinterName.Contains("TP805")) { DrawerOpen = new byte[] { 27, 112, 0, 250, 250 }; }
            else if (PrinterName.Contains("TP820")) { DrawerOpen = new byte[] { 27, 112, 0, 100, 250 }; }
            else if (PrinterName.Contains("TRST-53")) { DrawerOpen = new byte[] { 27, 112, 0, 100, 250 }; }
            else if (PrinterName.Contains("TRST-56")) { DrawerOpen = new byte[] { 27, 112, 0, 100, 250 }; }
            else if (PrinterName.Contains("TRST-A10")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("TRST-A15")) { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }
            else if (PrinterName.Contains("TSP 100IIU")) { DrawerOpen = new byte[] { 27, 7, 11, 55, 7 }; }
            else if (PrinterName.Contains("TSP 100ii")) { DrawerOpen = new byte[] { 7 }; }
            else if (PrinterName.Contains("TSP 100")) { DrawerOpen = new byte[] { 7 }; }
            else if (PrinterName.Contains("TSP 143iii")) { DrawerOpen = new byte[] { 27, 112, 0, 127, 127 }; }
            else if (PrinterName.Contains("TSP-100")) { DrawerOpen = new byte[] { 7 }; }
            else if (PrinterName.Contains("TSP200")) { DrawerOpen = new byte[] { 27, 7, 11, 55, 7 }; }
            else if (PrinterName.Contains("TSP-600")) { DrawerOpen = new byte[] { 7 }; }
            else if (PrinterName.Contains("TSP-613TSP")) { DrawerOpen = new byte[] { 7 }; }
            else if (PrinterName.Contains("TSP-650TSP")) { DrawerOpen = new byte[] { 7 }; }
            else if (PrinterName.Contains("TSP-650")) { DrawerOpen = new byte[] { 27, 112, 0, 48 }; }
            else if (PrinterName.Contains("TSP-654iic")) { DrawerOpen = new byte[] { 7 }; }
            else if (PrinterName.Contains("TSP-700ii")) { DrawerOpen = new byte[] { 27, 07, 11, 55, 07 }; }
            else if (PrinterName.Contains("TSP-700")) { DrawerOpen = new byte[] { 27, 07, 11, 55, 07 }; }
            else if (PrinterName.Contains("TSP-743ii")) { DrawerOpen = new byte[] { 27, 7, 11, 55, 7 }; }
            else if (PrinterName.Contains("U808")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 25 }; }
            else if (PrinterName.Contains("WTP-100")) { DrawerOpen = new byte[] { 27, 112, 49, 48, 48 }; }
            else if (PrinterName.Contains("XP-350-B")) { DrawerOpen = new byte[] { 27, 112, 0, 148, 49 }; }
            else if (PrinterName.Contains("XP-360")) { DrawerOpen = new byte[] { 27, 112, 0, 148, 49 }; }
            else if (PrinterName.Contains("XP-58iih")) { DrawerOpen = new byte[] { 27, 112, 0, 148, 49 }; }
            else if (PrinterName.Contains("XP-58iim")) { DrawerOpen = new byte[] { 27, 112, 0, 148, 49 }; }
            else if (PrinterName.Contains("XP-C20-K")) { DrawerOpen = new byte[] { 27, 112, 0, 148, 49 }; }
            else if (PrinterName.Contains("XP-F900")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("XR-200")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("XR-250")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("XR-500")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }
            else if (PrinterName.Contains("ZJ-8200")) { DrawerOpen = new byte[] { 27, 112, 0, 48, 48 }; }
            else if (PrinterName.Contains("ZJ-8250")) { DrawerOpen = new byte[] { 27, 112, 0, 25, 250 }; }

            else { DrawerOpen = new byte[] { 27, 112, 48, 55, 121 }; }


            return DrawerOpen;
        }

        public static byte[] getCode1(string PrinterName)
        {
            byte[] DrawerOpen = new byte[] { };

            string retstr = getModel(PrinterName);

            if(retstr=="")
            {
                DrawerOpen = new byte[] { 27, 112, 48, 55, 121 };
            }

            string Manufacturer = retstr.Split('^')[0].Trim();
            string Model = retstr.Split('^')[1].Trim();

            string Sql = "select * from CashDrawerLibrary where Manufacturer like '%" + Manufacturer + "%' and  Model like '%" + Model + "%'";
            DataTable dt1 = DataAccess.GetDataTable(Sql);

            if (dt1.Rows.Count > 0)
            {
                string codes = dt1.Rows[0]["Drawer_Codes"].ToString().Trim();

                string[] code;
                if(codes.Contains(","))
                {
                    code = codes.Split(',');
                }
                else
                {
                    code = new string[1];
                    code[0] = codes;
                }               
                int len = code.Length;
                byte[] DrawerOpen1 = new byte[len];
                for(int i=0;i<len;i++)
                {
                    string Co = code[i].ToString().Trim();
                    DrawerOpen1[i] = Convert.ToByte(Co);
                }
                DrawerOpen = DrawerOpen1;
            }
            return DrawerOpen;
        }

        public static string getModel(string PrinterName)
        {
            PrinterName = PrinterName.ToUpper();
            string ModelName = "";
            string Sql = "select * from CashDrawerLibrary";
            DataTable dt1 = DataAccess.GetDataTable(Sql);

            int coun = dt1.Rows.Count;
            string[] Model = new string[coun];
            string[] Manufacturer = new string[coun];

            if (coun > 0)
            {
                for(int i=0;i<coun;i++)
                {
                    Model[i] = dt1.Rows[i]["Model"].ToString().ToUpper();
                    Manufacturer[i] = dt1.Rows[i]["Manufacturer"].ToString().ToUpper();
                }
            }

            for(int j = 0; j<coun;j++)
            {
                if (PrinterName.Contains(Manufacturer[j]))
                {
                    if (PrinterName.Contains(Model[j]))
                    {
                        ModelName = Manufacturer[j].Trim() +" ^ "+  Model[j].Trim();
                        return ModelName;
                    }
                }                
            }

            return ModelName;
        }

    }
}
