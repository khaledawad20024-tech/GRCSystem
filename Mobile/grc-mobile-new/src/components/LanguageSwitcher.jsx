import { Ionicons } from "@expo/vector-icons";
import { StyleSheet, Text, TouchableOpacity } from "react-native";

import { useLanguage } from "../contexts/LanguageContext";

export default function LanguageSwitcher() {
  const { language, toggleLanguage } = useLanguage();

  return (
    <TouchableOpacity style={styles.container} onPress={toggleLanguage}>
      <Ionicons name="globe-outline" size={20} color="#0F172A" />

      <Text style={styles.text}>
        {language === "ar" ? "العربية" : "English"}
      </Text>
    </TouchableOpacity>
  );
}

const styles = StyleSheet.create({
  container: {
    flexDirection: "row",
    alignItems: "center",
    gap: 8,

    backgroundColor: "#F8FAFC",

    borderWidth: 1,
    borderColor: "#E2E8F0",

    paddingHorizontal: 12,
    paddingVertical: 8,

    borderRadius: 12,
  },

  text: {
    color: "#0F172A",
    fontSize: 14,
    fontWeight: "600",
  },
});
