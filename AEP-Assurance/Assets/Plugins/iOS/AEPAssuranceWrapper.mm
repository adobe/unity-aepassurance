/*
AEPAssuranceWrapper.mm

Copyright 2020 Adobe. All rights reserved.
This file is licensed to you under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License. You may obtain a copy
of the License at http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software distributed under
the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR REPRESENTATIONS
OF ANY KIND, either express or implied. See the License for the specific language
governing permissions and limitations under the License.
*/

#import "AEPAssuranceWrapper.h"
#import "AEPAssurance.h"

bool aep_RegisterExtension(){
    return [AEPAssurance registerExtension];
}

void aep_StartSession(const char* url){
    [AEPAssurance startSession:[[NSURL alloc] initWithString:[NSString stringWithCString:url encoding:NSUTF8StringEncoding ]]];
}

const char *aep_AssuranceExtensionVersion(){
    return [[AEPAssurance extensionVersion] cStringUsingEncoding:NSUTF8StringEncoding];
}
