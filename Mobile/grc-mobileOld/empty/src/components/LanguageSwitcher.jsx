import { StyleSheet, Text, TouchableOpacity } from "react-native";

import { useState } from "react";

export default function LanguageSwitcher() {
  const [lang, setLang] = useState("AR");

  const changeLanguage = () => {
    setLang(lang === "AR" ? "EN" : "AR");
  };

  return (
    <TouchableOpacity onPress={changeLanguage} style={styles.button}>
      <Text style={styles.text}>{lang}</Text>
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
