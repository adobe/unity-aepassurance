#ifndef Unity_iPhone_ACPCoreWrapper_h
#define Unity_iPhone_ACPCoreWrapper_h

extern "C" {
    bool GriffonRegisterExtension();
    const char *GriffonExtensionVersion();
    void Griffon_StartSession(const char* url);
    void Griffon_EndSession();
    void GriffonAttemptReconnect();
    void SendGriffonEvent(const char* vendor, const char* type, const char* payload);
    void GriffonLogLocalUILevel(int localLogLevel, const char* message);
}

#endif
