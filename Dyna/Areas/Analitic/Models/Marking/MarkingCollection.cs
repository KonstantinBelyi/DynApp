using System.Collections.Generic;

namespace Dyna.Areas.Analitic.Models.Marking
{
    public class MarkingCollection
    {
        public static List<DraftPins> WithDraft
        {
            get
            {
                return ExecuteMarking.GetDealWithDraft();
            }
        }
        public static List<CleanPins> WithoutDraft
        {
            get
            {
                return ExecuteMarking.GetDealWithoutDraft();
            }
        }
        public static string IncomingPins
        {
            set
            {
                ExecuteMarking.SetIncomingPins(value);
            }
        }
        public static string[] IncomingPinsFile
        {
            set
            {
                ExecuteMarking.SetIncomingPins(value);
            }
        }
    }
}