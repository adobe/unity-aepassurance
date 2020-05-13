/*
GriffonUnityBridge.h
Copyright 2020 Adobe
All Rights Reserved.

NOTICE: Adobe permits you to use, modify, and distribute this file in
accordance with the terms of the Adobe license agreement accompanying
it. If you have received this file from a source other than Adobe,
then your use, modification, or distribution of it requires the prior
written permission of Adobe.
*/

#ifndef Unity_iPhone_ACPGriffonWrapper_h
#define Unity_iPhone_ACPGriffonWrapper_h

extern "C" {
    bool acp_RegisterExtension();
    void acp_StartSession(const char* url);
    const char *acp_GriffonExtensionVersion();
}

#endif
