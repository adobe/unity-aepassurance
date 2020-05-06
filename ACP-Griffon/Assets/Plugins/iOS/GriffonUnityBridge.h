#ifndef Unity_iPhone_ACPGriffonWrapper_h
#define Unity_iPhone_ACPGriffonWrapper_h

extern "C" {
    bool Griffon_RegisterExtension();
    void Griffon_StartSession(const char* url);
    const char *Griffon_ExtensionVersion();
}

#endif
