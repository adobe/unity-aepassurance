
#import "GriffonUnityBridge.h"
#import "ACPGriffon.h"

const char *GriffonExtensionVersion(){
    return [[ACPGriffon extensionVersion] cStringUsingEncoding:NSUTF8StringEncoding];
}

void Griffon_StartSession(const char* url){
    [ACPGriffon startSession:[[NSURL alloc] initWithString:[[NSString alloc] initWithUTF8String:url]]];
}

bool GriffonRegisterExtension(){
    return [ACPGriffon registerExtension];
}


