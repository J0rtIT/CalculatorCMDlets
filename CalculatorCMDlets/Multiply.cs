using System;
using System.Management.Automation;

namespace CalculatorCMDlets
{
    [Cmdlet(MyVerb.Multiply, "Ints")]
    public class Multiply : Cmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public string NumberA { get; set; }

        [Parameter(Mandatory = true, Position = 1, ValueFromPipeline = true)]
        public string NumberB { get; set; }

        private int A { get; set; }
        private int B { get; set; }
        private int Result { get; set; }


        protected override void BeginProcessing()
        {
            try
            {
                A = Convert.ToInt32(NumberA);
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(new Exception($"NumberA can't be converted into Number. Message: {ex.Message}"), "1", ErrorCategory.InvalidArgument, null));
            }


            try
            {
                B = Convert.ToInt32(NumberB);
            }
            catch (Exception ex)
            {
                WriteError(new ErrorRecord(new Exception($"NumberB can't be converted into Number. Message: {ex.Message}"), "1", ErrorCategory.InvalidArgument, null));
            }
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            Result = A * B;
            base.ProcessRecord();
        }

        protected override void EndProcessing()
        {
            WriteObject(Result);
            base.EndProcessing();
        }

        protected override void StopProcessing()
        {
            WriteError(new ErrorRecord(new Exception("Cmdlet Execution Stopped"), "1", ErrorCategory.InvalidArgument, null));
            base.StopProcessing();
        }
    }
}
