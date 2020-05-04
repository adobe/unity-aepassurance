
#import "GriffonUnityBridge.h"
#import "ACPGriffon.h"

bool GriffonRegisterExtension(){
    return [ACPGriffon registerExtension];
}

void Griffon_StartSession(const char* url){
    [ACPGriffon startSession:[[NSURL alloc] initWithString:[NSString stringWithCString:url encoding:NSUTF8StringEncoding ]]];
}

const char *GriffonExtensionVersion(){
    return [[ACPGriffon extensionVersion] cStringUsingEncoding:NSUTF8StringEncoding];
}
