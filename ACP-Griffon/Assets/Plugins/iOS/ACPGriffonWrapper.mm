/*
GriffonUnityBridge.mm
Copyright 2020 Adobe
All Rights Reserved.

NOTICE: Adobe permits you to use, modify, and distribute this file in
accordance with the terms of the Adobe license agreement accompanying
it. If you have received this file from a source other than Adobe,
then your use, modification, or distribution of it requires the prior
written permission of Adobe.
*/

#import "ACPGriffonWrapper.h"
#import "ACPGriffon.h"

bool acp_RegisterExtension(){
    return [ACPGriffon registerExtension];
}

void acp_StartSession(const char* url){
    [ACPGriffon startSession:[[NSURL alloc] initWithString:[NSString stringWithCString:url encoding:NSUTF8StringEncoding ]]];
}

const char *acp_GriffonExtensionVersion(){
    return [[ACPGriffon extensionVersion] cStringUsingEncoding:NSUTF8StringEncoding];
}
