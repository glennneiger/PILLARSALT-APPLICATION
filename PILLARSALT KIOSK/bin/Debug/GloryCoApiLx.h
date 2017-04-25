/******************************************************************************

         Copyright (C) 2009 - 2011 Glory Ltd. All rights reserved.

*******************************************************************************/

#ifndef	__GLORY_LTD_HEADER_API_
#define	__GLORY_LTD_HEADER_API_

#ifdef	WIN32
#pragma pack(push,1)
#endif

#ifdef __cplusplus
extern "C" {
#endif


void GLY_SetConfigurationFile(const char* filename);

int GLY_GsiOpen (const char* lpLogicalName, GLYHANDLE* h, GLYCALLBACK pcb);
int GLY_GsiOpenEx (const char* lpLogicalName, GLYHANDLE* h, GLYCALLBACK pcb);
int GLY_OpenDirect(const char* lpLogicalName, GLYHANDLE* h, const char* config);
int GLY_GsiOpenDirect(const char* lpLogicalName, GLYHANDLE* h, GLYCALLBACK pcb, const char* config);
int GLY_Close(GLYHANDLE h);
int GLY_FreeMemory(void* p);
int GLY_GetStringFromID(GLYHANDLE h, int id, char** lppString);
int GLY_SetStringOfID(GLYHANDLE h, int id, const char* lpString);
int GLY_WriteTrace(const char* str);
int GLY_Open(const char* lpLogicalName, GLYHANDLE* h);
int GLY_SetCallBack(GLYHANDLE h, GLYCALLBACK cb);
int GLY_GetStatus(GLYHANDLE h, int* lpdwStatus);
int GLY_AsyncLock(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID, unsigned int dwTimeOut);
int GLY_Lock(GLYHANDLE h, unsigned int dwTimeOut);
int GLY_AsyncUnlock(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_Unlock(GLYHANDLE h);
int GLY_CancelRequest(GLYHANDLE h, GLYREQUESTID RequestID);
int GLY_AsyncReset(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_Reset(GLYHANDLE h);
int GLY_AsyncDeposit(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_Deposit(GLYHANDLE h, LPGLYDENOMINATION* lppDenomination);
int GLY_AsyncAutoRepetitiveDeposit(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_AutoRepetitiveDeposit(GLYHANDLE h, LPGLYDENOMINATION* lppDenomination);
int GLY_AbortInterruptDeposit(GLYHANDLE h);
int GLY_AsyncStore(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_Store(GLYHANDLE h);
int GLY_AsyncCancelDeposit(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_CancelDeposit(GLYHANDLE h);
int GLY_AsyncDispense(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID, LPGLYDENOMINATION lpDenomination);
int GLY_Dispense(GLYHANDLE h, LPGLYDENOMINATION lpDenomination, LPGLYDENOMINATION* lppDenomination);
int GLY_AsyncPresent(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_Present(GLYHANDLE h);
int GLY_AsyncCancelDispense(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_CancelDispense(GLYHANDLE h);
int GLY_AsyncReplenish(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_Replenish(GLYHANDLE h);
int GLY_AsyncReplenishEnd(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_ReplenishEnd(GLYHANDLE h, LPGLYDENOMINATION* lppDenomination);
int GLY_AsyncRefill(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_Refill(GLYHANDLE h);
int GLY_AsyncRefillEnd(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_RefillEnd(GLYHANDLE h, LPGLYDENOMINATION* lppDenomination);
int GLY_AsyncCollect(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_AsyncCollectEx(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID, LPGLYDENOMINATION lpDenomination);
int GLY_Collect(GLYHANDLE h, LPGLYDENOMINATION* lppDenomination);
int GLY_CollectEx(GLYHANDLE h, LPGLYDENOMINATION lpDenom, LPGLYDENOMINATION* lppDenomination);
int GLY_AsyncNumberCounting(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);
int GLY_NumberCounting(GLYHANDLE h);
int GLY_AsyncNumberCountingEnd(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);
int GLY_NumberCountingEnd(GLYHANDLE h);
int GLY_AsyncVerify(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);
int GLY_Verify(GLYHANDLE h);
int GLY_AsyncVerifyEnd(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);
int GLY_VerifyEnd(GLYHANDLE h);
int GLY_AsyncGetCounter(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);
int GLY_GetCounter(GLYHANDLE h, LPGLYCOUNTERS* lppCounters);
int GLY_AsyncSetCounter(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID, LPGLYCOUNTERS lpCounters);
int GLY_SetCounter(GLYHANDLE h, LPGLYCOUNTERS lpCounters);
int GLY_AsyncGetCassetteConfiguration(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);
int GLY_GetCassetteConfiguration(GLYHANDLE h, LPGLYCOUNTERS* lppConfig);
int GLY_AsyncSetCassetteConfiguration(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID, LPGLYCOUNTERS lpConfig);
int GLY_SetCassetteConfiguration(GLYHANDLE h, LPGLYCOUNTERS lpConfig);
int GLY_AsyncGetTime(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);
int GLY_GetTime(GLYHANDLE h, struct tm** lppTime);
int GLY_AsyncSetTime(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID, struct tm* lpTime);
int GLY_SetTime(GLYHANDLE h, struct tm* lpTime);
int GLY_AsyncLogRead(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID, const char** logname, int tevent);
int GLY_LogRead(GLYHANDLE h, const char** logname, int tevent, char** lppLog);
int GLY_AsyncLogReadByFile(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID, const char* filename, const char* pattern, int tevent);
int GLY_LogReadByFile(GLYHANDLE h, const char* filename, const char* patturn, int tevent, char** ppLogs);
int GLY_AsyncLogClear(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID, const char** logname);
int GLY_LogClear(GLYHANDLE h, const char** logname);
int GLY_AsyncLogClearByFile(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID, const char* filename, const char* pattern);
int GLY_LogClearByFile(GLYHANDLE h, const char* filename, const char* pattern);
int GLY_AsyncDownload(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID, const char* filename, const char* patturn, int tevent);
int GLY_Download(GLYHANDLE h, const char* filename, const char* patturn, int tevent);
int GLY_AsyncGetDeviceProperty(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID, const char* propname);
int GLY_GetDeviceProperty(GLYHANDLE h, const char* propname, LPGLYPROPERTY* lppProperty);
int GLY_AsyncSetDeviceProperty(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID, LPGLYPROPERTY lpProperty);
int GLY_SetDeviceProperty(GLYHANDLE h, LPGLYPROPERTY lpProperty);

const char* GLY_GetIDString(int id);
const char* GLY_GetIDStringInDevice(GLYHANDLE h, int id);
int GLY_GetIDFromString(const char* str);
int GLY_isIDExist(const char* st);
int GLY_SetControlProperty(GLYHANDLE h, LPGLYPROPERTY prop);

/**
	Debug use
	Return : String Table corresponding to IDs
	Returned pointer must be released by GLY_FreeMemory()
*/
GLYIDANDSTRINGTABLE* GLY_GetIDAndStringTable();

int GLY_GetLogicalName(GLYHANDLE h, char** ppName);
int GLY_GetConfigFileName(GLYHANDLE h, char** ppName);
int GLY_GetDeviceType(GLYHANDLE h, char** ppType);

/**
	APIs below are for compatibility with DLL version 2009.
*/
int GLY_AsyncStoreContinueToDeposit(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_AsyncPresentContinueToDispense(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_AsyncIntermediateCollect(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID, LPGLYDENOMINATION lpDenomination);
int GLY_AsyncNumberCountingEx(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID, int dwFullNumber);
int GLY_AsyncReadCounter(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_AsyncWriteCounter(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID, LPGLYCOMMONCOUNTERS lpCommonCounter);
int GLY_AsyncLogon(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID, unsigned char* lpString);
int GLY_AsyncLogout(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_AsyncDeviceSpecificCommand(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID, LPGLYDEVICESPECIFICCOMMAND lpInParam);
int GLY_AsyncDeviceSpecificCommandByString(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID, const char* lpInParam);
int GLY_AsyncStoreInterruptDeposit (GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID, LPGLYDENOMINATION lpDenomination);
int GLY_AsyncCancelInterruptDeposit(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_AsyncSetPassword(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID, unsigned char* lpString);
int GLY_AsyncSetHandleName(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID, const char* lpString);
int GLY_AsyncGetHandleName(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_SetHandleName(GLYHANDLE h, const char* lpString);
int GLY_GetHandleName(GLYHANDLE h, char** lpString);
int GLY_AsyncEndInterruptCounterCorrection(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID, LPGLYDENOMINATION lpDenomination);
int GLY_AsyncCounterCorrectionEnd(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_AsyncCounterCorrection(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_AsyncLoading(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_ReadCounter(GLYHANDLE h, LPGLYCOMMONCOUNTERS* lppCommonCounter);
int GLY_WriteCounter(GLYHANDLE h, LPGLYCOMMONCOUNTERS lpCommonCounter);
int GLY_AlarmOn(GLYHANDLE h, int rn, unsigned int ontime);
int GLY_AlarmOff(GLYHANDLE h, int rn);
int GLY_AbortInterruptCounterCorrection(GLYHANDLE h);
int GLY_IntermediateCollect(GLYHANDLE h, LPGLYDENOMINATION lpDenomination, LPGLYDENOMINATION* lppDenomination);
int GLY_DeviceSpecificCommand(GLYHANDLE h, LPGLYDEVICESPECIFICCOMMAND lpInParam, LPGLYDEVICESPECIFICCOMMAND* lppOutParam);
int GLY_DeviceSpecificCommandByString(GLYHANDLE h, const char* lpInParam, char** lppOutParam);

int GLY_SetPassword(GLYHANDLE h, unsigned char* lpString);
int GLY_Logon(GLYHANDLE h, unsigned char* lpString);
int GLY_Logout(GLYHANDLE h);
int GLY_StoreContinueToDeposit(GLYHANDLE h);
int GLY_StoreInterruptDeposit(GLYHANDLE h, LPGLYDENOMINATION lpDenomination);
int GLY_CancelInterruptDeposit(GLYHANDLE h);
int GLY_PresentContinueToDispense(GLYHANDLE h);
int GLY_CounterCorrection(GLYHANDLE h, LPGLYDENOMINATION* lppDenomination);
int GLY_CounterCorrectionEnd(GLYHANDLE h);
int GLY_EndInterruptCounterCorrection(GLYHANDLE h, LPGLYDENOMINATION lpDenomination);
int GLY_NumberCountingEx(GLYHANDLE h, int dwFullNumber);
int GLY_SetHandleName(GLYHANDLE h, const char* lpString);
int GLY_GetHandleName(GLYHANDLE h, char** lpString);

/**
	APIs below are not necessary.
6. 3. 1. GLY_AsyncSend
6. 3. 2. GLY_Send
6. 3. 3. GLY_AsyncSendRev1
6. 3. 4. GLY_SendRev1
6. 3. 5. GLY_AsyncReceive
6. 3. 6. GLY_Receive
6. 3. 7. GLY_AsyncReceiveRev1
6. 3. 8. GLY_ReceiveRev1
*/

// vvvvvvvvvvvvvvvvvv For OPOS vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
int GLY_OpenPOS(const char* lpLogicalName, GLYHANDLE* h);
int GLY_Claim(GLYHANDLE h, int dwTimeOut);
int GLY_Release(GLYHANDLE h);
int GLY_AsyncStartCommunication(GLYHANDLE h, GLYCALLBACK hWnd, LPGLYREQUESTID lpRequestID);
int GLY_StartCommunication(GLYHANDLE h);
int GLY_StopCommunication(GLYHANDLE h);
int GLY_GetProperty(GLYHANDLE h, int propIndex);
int GLY_GetSupportedCashList(GLYHANDLE h, LPGLYCOMMONCOUNTERS* lppCommonCounter);
int GLY_GetExitCashList(GLYHANDLE h, int exitNo, LPGLYDENOMINATION* lppDenomination);
int GLY_CompareFirmwareVersion(GLYHANDLE h, const char* pFirmwareFile, unsigned char* lppResult);
int GLY_GetLogNames(GLYHANDLE h, const char*** pppLogNames);

//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

// vvvvvvvvvvvvvvvvvv For RBW-10 vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
int GLY_DoNotAccept(GLYHANDLE h, int faceValue);
int GLY_DoAccept(GLYHANDLE h, int faceValue);
int GLY_AsyncDepositOverride(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_DepositOverride(GLYHANDLE h);


// vvvvvvvvvvvvvvvvvv For New Framework vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
int GLY_AsyncGetDeviceVersion(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID);
int GLY_GetDllVersion(GLYHANDLE h, LPGLYMODULEVERSION* lppModuleVersion);
int GLY_GetDeviceVersion(GLYHANDLE h, LPGLYMODULEVERSION* lppModuleVersion);
int GLY_AsyncGetOperationMode(GLYHANDLE h, GLYCALLBACK pcb, LPGLYREQUESTID lpRequestID, const char* OperationName);
int GLY_AsyncSetOperationMode(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID, LPGLYOPERATIONMODE lpProperty);
int GLY_GetOperationMode(GLYHANDLE h, const char* OperationName, LPGLYOPERATIONMODE* lppProperty);
int GLY_SetOperationMode(GLYHANDLE h, LPGLYOPERATIONMODE lpProperty);
int GLY_AsyncStopCommunication(GLYHANDLE h, GLYCALLBACK cb, LPGLYREQUESTID lpRequestID);
int GLY_GetDLLProperty(GLYHANDLE h, const char* propname, LPGLYPROPERTY* lppProperty);
int GLY_SetDLLProperty(GLYHANDLE h, LPGLYPROPERTY lpProperty);
int GLY_AsyncDeviceRequest(GLYHANDLE h, int cmd, GLYCALLBACK pcb, int* RequestID, void* InParam);
int GLY_DeviceRequest(GLYHANDLE h, int cmd, void* InParam, void** OutParam);

//^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

// vvvvvvvvvvvvvvvvvv RBG-100,200 vvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvvv
int GLY_AsyncDirectDeposit(GLYHANDLE h, GLYCALLBACK hWnd, LPGLYREQUESTID lpRequestID);

#ifdef __cplusplus
}
#endif

#ifdef	WIN32
#pragma pack(pop)
#endif

#endif	// __GLORY_LTD_HEADER_API_
