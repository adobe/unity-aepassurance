
#import "GriffonUnityBridge.h"
#import "ACPGriffon.h"

bool Griffon_RegisterExtension(){
    return [ACPGriffon registerExtension];
}

void Griffon_StartSession(const char* url){
    [ACPGriffon startSession:[[NSURL alloc] initWithString:[NSString stringWithCString:url encoding:NSUTF8StringEncoding ]]];
}

const char *Griffon_ExtensionVersion(){
    return [[ACPGriffon extensionVersion] cStringUsingEncoding:NSUTF8StringEncoding];
}
