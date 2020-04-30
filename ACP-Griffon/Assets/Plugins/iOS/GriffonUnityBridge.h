#ifndef Unity_iPhone_ACPCoreWrapper_h
#define Unity_iPhone_ACPCoreWrapper_h

extern "C" {
    const char *GriffonExtensionVersion();
    void Griffon_StartSession(const char* url);
    bool GriffonRegisterExtension();
}

#endif
