using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;


namespace Validate
{
    public class Validation : IParameterInspector
    {
        public void AfterCall(string operationName, object[] outputs, object returnValue, object correlationState)
        {
            //throw new NotImplementedException();
        }

        public object BeforeCall(string operationName, object[] inputs)
        {
            if (operationName == "CreateEmployee")
            {
                string employeeId;
                employeeId=inputs[0].ToString().Trim();
                if ((employeeId == "") || (employeeId == null))
                {
                    throw new FaultException(new FaultReason("Employee Id Null not allowed"), new FaultCode("100"));
                }
            }
            if (operationName == "EmployeeRemark")
            {
                string employeeRemark;
                employeeRemark = inputs[1].ToString().Trim();
                if ((employeeRemark == "") || (employeeRemark == null))
                {
                    throw new FaultException(new FaultReason("Employee Remark Null not allowed"), new FaultCode("110"));
                }
            }
            return null;
        }
    }

    class ValidationBehavior : IEndpointBehavior
    {
        private bool enabled;
        #region IEndpointBehavior Members

        internal ValidationBehavior(bool enabled)
        {
            this.enabled = enabled;
        }

        public bool Enabled
        {
            get { return enabled; }
            set { enabled = value; }
        }

        public void AddBindingParameters(ServiceEndpoint serviceEndpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        { }

        public void ApplyClientBehavior(
          ServiceEndpoint endpoint,
          ClientRuntime clientRuntime)
        {
            //If enable is not true in the config we do not apply the Parameter Inspector
            if (false == this.enabled)
            {
                return;
            }

            foreach (ClientOperation clientOperation in clientRuntime.Operations)
            {
                clientOperation.ParameterInspectors.Add(
                    new Validation());
            }

        }

        public void ApplyDispatchBehavior(
           ServiceEndpoint endpoint,
           EndpointDispatcher endpointDispatcher)
        {
            //If enable is not true in the config we do not apply the Parameter Inspector

            if (false == this.enabled)
            {
                return;
            }

            foreach (DispatchOperation dispatchOperation in endpointDispatcher.DispatchRuntime.Operations)
            {

                dispatchOperation.ParameterInspectors.Add(
                    new Validation());
            }

        }

        public void Validate(ServiceEndpoint serviceEndpoint)
        {

        }

        #endregion
    }

    public class CustomBehaviorSection : BehaviorExtensionElement
    {

        private const string EnabledAttributeName = "enabled";

        [ConfigurationProperty(EnabledAttributeName, DefaultValue = true, IsRequired = false)]
        public bool Enabled
        {
            get { return (bool)base[EnabledAttributeName]; }
            set { base[EnabledAttributeName] = value; }
        }

        protected override object CreateBehavior()
        {
            return new ValidationBehavior(this.Enabled);
        }

        public override Type BehaviorType
        {
            get { return typeof(ValidationBehavior); }
        }
    }


}
