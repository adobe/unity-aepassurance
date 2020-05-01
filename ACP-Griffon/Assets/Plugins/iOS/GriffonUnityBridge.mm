
#import "GriffonUnityBridge.h"
#import "ACPGriffon.h"
#import "ACPGriffonEvent.h"

//Helper function
NSDictionary *_getDictionaryFromJsonString(const char *jsonString) {
    if (!jsonString) {
        return nil;
    }
    
    NSError *error = nil;
    NSString *tempString = [NSString stringWithCString:jsonString encoding:NSUTF8StringEncoding];
    NSData *data = [tempString dataUsingEncoding:NSUTF8StringEncoding];
    NSDictionary *dict = [NSJSONSerialization JSONObjectWithData:data
                                                         options:NSJSONReadingMutableContainers
                                                           error:&error];
    
    return (dict && !error) ? dict : nil;
}

const char *GriffonExtensionVersion(){
    return [[ACPGriffon extensionVersion] cStringUsingEncoding:NSUTF8StringEncoding];
}

void Griffon_StartSession(const char* url){
    [ACPGriffon startSession:[[NSURL alloc] initWithString:[NSString stringWithCString:url encoding:NSUTF8StringEncoding ]]];
}

bool GriffonRegisterExtension(){
    return [ACPGriffon registerExtension];
}

void Griffon_EndSession(){
    [ACPGriffon endSession];
}

void GriffonAttemptReconnect(){
    [ACPGriffon attemptReconnect];
}

void SendGriffonEvent(const char* vendor, const char* type, const char* payload){
    ACPGriffonEvent* acpGriffonEvent = [[ACPGriffonEvent alloc] initWithVendor:[NSString stringWithCString:vendor encoding:NSUTF8StringEncoding] type:[NSString stringWithCString:type encoding:NSUTF8StringEncoding] payload:_getDictionaryFromJsonString(payload)];
    
    [ACPGriffon sendEvent:acpGriffonEvent];
}

void GriffonLogLocalUILevel(int localLogLevel, const char* message){
    [ACPGriffon logLocalUILevel:ACPGriffonUILogColor(localLogLevel) message:[NSString stringWithCString:message encoding:NSUTF8StringEncoding]];
}


