import { StyleSheet, Text, TouchableOpacity, View } from "react-native";

import { Ionicons } from "@expo/vector-icons";

import LanguageSwitcher from "./LanguageSwitcher";

export default function AppHeader({
  title,
  sidebarVisible,
  setSidebarVisible,
}) {
  return (
    <View style={styles.header}>
      <TouchableOpacity onPress={() => setSidebarVisible(!sidebarVisible)}>
        <Ionicons name="menu" size={30} color="#fff" />
      </TouchableOpacity>

      <Text style={styles.title}>{title}</Text>

      <LanguageSwitcher />
    </View>
  );
}

const styles = StyleSheet.create({
  header: {
    height: 60,
    backgroundColor: "#0056A6",

    flexDirection: "row",

    alignItems: "center",

    justifyContent: "space-between",

    paddingHorizontal: 15,
  },

  title: {
    color: "#fff",
    fontSize: 20,
    fontWeight: "bold",
  },
});
