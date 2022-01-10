VERSION=$(shell grep 'Plug-in v:' AEPAssurance/Assets/Plugins/AEPAssurance.cs | sed 's/.*Plug-in v.*:[[:space:]]*\(.*\)[[:space:]]*/\1/')
RELEASE_DIR=AEPAssurance-$(VERSION)-Unity
MOBILE_DIR=$(RELEASE_DIR)/AEPAssurance
UNITY_BIN=/Applications/Unity/Hub/Editor/2019.4.34f1/Unity.app/Contents/MacOS/Unity
ROOT_DIR=.
CURRENT_PATH=$(shell pwd)
PROJECT_DIR=$(CURRENT_PATH)/AEPAssurance
BIN_DIR=$(ROOT_DIR)/bin
BUILD_DIR=$(BIN_DIR)/build_temp
BUILD_PKG=AEPAssurance.unitypackage
ASSETS=Assets/Plugins/android/AndroidManifest.xml Assets/Plugins/android/mainTemplate.gradle $(shell find AEPAssurance/Assets/Plugins -type f -iname "*assurance*" -not -name "*.meta" | sed 's/.*AEPAssurance*\///')

# targets
release: clean setup unity_build

unity_build:
	@echo ""
	@echo "######################################################################"
	@echo "### Make all - "$@
	@echo "######################################################################"
	mkdir -p $(BUILD_DIR)/$(RELEASE_DIR)
	mkdir -p $(BUILD_DIR)/$(MOBILE_DIR)

	@echo ""
	@echo "######################################################################"
	@echo "### Build Unity Plugin - "$@
	@echo "######################################################################"
	$(UNITY_BIN) -batchmode -quit \
	-logFile $(BUILD_DIR)/buildLog.log \
	-projectPath $(PROJECT_DIR) \
	-exportPackage $(ASSETS) ../$(BUILD_DIR)/$(MOBILE_DIR)/$(BUILD_PKG)

	@echo ""
	@echo "######################################################################"
	@echo "### Zip Unity Plugin for Distribution - "$@
	@echo "######################################################################"
	cd $(BUILD_DIR) && zip -r -X $(RELEASE_DIR).zip ./$(RELEASE_DIR)
	mv $(BUILD_DIR)/$(RELEASE_DIR).zip $(BIN_DIR)

clean:
	rm -rf $(BUILD_DIR)

setup:
	mkdir $(BUILD_DIR)