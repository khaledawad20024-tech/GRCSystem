import { Slot } from "expo-router";
import { View } from "react-native";
import { LanguageProvider, useLanguage } from "../contexts/LanguageContext";

function LayoutContent() {
  const { isRTL } = useLanguage();

  return (
    <View
      style={{
        flex: 1,
        direction: isRTL ? "rtl" : "ltr",
      }}
    >
      <Slot />
    </View>
  );
}

export default function RootLayout() {
  return (
    <LanguageProvider>
      <LayoutContent />
    </LanguageProvider>
  );
}
