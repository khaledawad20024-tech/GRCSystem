import { StyleSheet, Text, TouchableOpacity } from "react-native";

import { Ionicons } from "@expo/vector-icons";

import { useLanguage } from "../contexts/LanguageContext";

export default function LanguageSwitcher() {
  const { language, toggleLanguage } = useLanguage();

  return (
    <TouchableOpacity style={styles.button} onPress={toggleLanguage}>
      <Text style={styles.text}>
        {language === "ar" ? "العربية" : "English"}
      </Text>

      <Ionicons name="globe-outline" size={18} color="#334155" />
    </TouchableOpacity>
  );
}

const styles = StyleSheet.create({
  button: {
    flexDirection: "row",
    alignItems: "center",
    gap: 5,
  },

  text: {
    color: "#334155",
    fontSize: 15,
    fontWeight: "500",
  },
});
