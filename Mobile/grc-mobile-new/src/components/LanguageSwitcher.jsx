import { StyleSheet, Text, TouchableOpacity } from "react-native";

import { useLanguage } from "../contexts/LanguageContext";

export default function LanguageSwitcher() {
  const { language, toggleLanguage } = useLanguage();

  return (
    <TouchableOpacity onPress={toggleLanguage} style={styles.button}>
      <Text style={styles.text}>{language === "ar" ? "AR" : "EN"}</Text>
    </TouchableOpacity>
  );
}

const styles = StyleSheet.create({
  button: {
    paddingHorizontal: 12,
    paddingVertical: 6,
    backgroundColor: "#fff",
    borderRadius: 8,
  },

  text: {
    color: "#0056A6",
    fontWeight: "bold",
  },
});
