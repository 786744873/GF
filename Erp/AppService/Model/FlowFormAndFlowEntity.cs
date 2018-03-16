using CommonService.Model.FlowManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppService.Model
{
    public class FlowFormAndFlowEntity
    {
        public P_Business_flow pbf;
        public P_Business_flow_form pbff;

        public P_Business_flow getPBF()
        {
            return pbf;
        }
        public void setPBF(P_Business_flow pbf)
        {
            this.pbf = pbf;
        }

        public P_Business_flow_form getPBFF()
        {
            return pbff;
        }

        public void setPBFF(P_Business_flow_form pbff)
        {
            this.pbff = pbff;
        }
    }
}