using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WformalarioServer.clases
{
    internal class Usuarios
    {
        private int intID;
        private string strNOMBRE;
        private int intEDAD;
        private string strGRADO;
        private string strTELEFONO;
        private string strINSTITUCION;
        private string strCORREO;
        private string strGENERO;
         //Los contructores de los atributos
        public Usuarios(int intID, string strNOMBRE, int intEDAD, string strGRADO, string strTELEFONO, string strINSTITUCION, string strCORREO, string strGENERO)
        {
            this.IntID = intID;
            this.StrNOMBRE = strNOMBRE;
            this.IntEDAD = intEDAD;
            this.StrGRADO = strGRADO;
            this.StrTELEFONO = strTELEFONO;
            this.StrINSTITUCION = strINSTITUCION;
            this.StrCORREO = strCORREO;
            this.StrGENERO = strGENERO;
        }
        // Líneas para la sobrecarga
        public Usuarios() 
        {
        }

        public int IntID { get => intID; set => intID = value; }
        public string StrNOMBRE { get => strNOMBRE; set => strNOMBRE = value; }
        public int IntEDAD { get => intEDAD; set => intEDAD = value; }
        public string StrGRADO { get => strGRADO; set => strGRADO = value; }
        public string StrTELEFONO { get => strTELEFONO; set => strTELEFONO = value; }
        public string StrINSTITUCION { get => strINSTITUCION; set => strINSTITUCION = value; }
        public string StrCORREO { get => strCORREO; set => strCORREO = value; }
        public string StrGENERO { get => strGENERO; set => strGENERO = value; }
    }
}
