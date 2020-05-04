#ifndef Unity_iPhone_ACPGriffonWrapper_h
#define Unity_iPhone_ACPGriffonWrapper_h

extern "C" {
    bool GriffonRegisterExtension();
    void Griffon_StartSession(const char* url);
    const char *GriffonExtensionVersion();
}

#endif
