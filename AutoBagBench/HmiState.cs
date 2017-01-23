using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBagBench
{
    public enum HmiState
    {
        NoState,
        ReadyAndWaitForNewReference,
        ReadyWithReferenceWaitForTarget,
        NewReferenceReadyForProduction,
        WaitingForAccessories,
        WaitingPackingBarcodeVerify,
        WaitingForBigBoxEntry,
        WaitForRejectBinEntry,
        WaitingNewReferenceFromServer,
        WaitingForSealer,
        WaitingForProcessable
    }
}
