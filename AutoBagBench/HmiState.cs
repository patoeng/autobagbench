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
        WaitingForProcessable,
        LoadingWorkOrder,
        ChangeBigBox
    }
}
