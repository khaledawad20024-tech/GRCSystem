import { Ionicons } from "@expo/vector-icons";
import { StyleSheet, Text, TouchableOpacity, View } from "react-native";

import { useLanguage } from "../contexts/LanguageContext";
import LanguageSwitcher from "./LanguageSwitcher";

export default function AppHeader({ title, toggleSidebar }) {
  const { isRTL } = useLanguage();

  return (
    <View
      style={[
        styles.header,
        {
          flexDirection: isRTL ? "row-reverse" : "row",
        },
      ]}
    >
      {/* LEFT / RIGHT SECTION */}
      <View style={styles.userSection}>
        <View style={styles.avatar}>
          <Ionicons name="person" size={18} color="#fff" />
        </View>
        <Text style={styles.userName}>admin</Text>
      </View>

      {/* TITLE */}
      <Text style={styles.title}>{title}</Text>

      {/* ACTIONS */}
      <View style={styles.actions}>
        <LanguageSwitcher />

        <TouchableOpacity onPress={toggleSidebar}>
          <Ionicons name="menu" size={28} color="#334155" />
        </TouchableOpacity>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  header: {
    height: 70,
    backgroundColor: "#FFFFFF",
    alignItems: "center",
    justifyContent: "space-between",
    paddingHorizontal: 20,
    borderBottomWidth: 1,
    borderBottomColor: "#E2E8F0",
  },

  title: {
    fontSize: 20,
    fontWeight: "700",
    color: "#0F172A",
  },

  userSection: {
    flexDirection: "row",
    alignItems: "center",
  },

  avatar: {
    width: 40,
    height: 40,
    borderRadius: 20,
    backgroundColor: "#2563EB",
    justifyContent: "center",
    alignItems: "center",
  },

  userName: {
    marginHorizontal: 10,
    fontWeight: "600",
    fontSize: 16,
  },

  actions: {
    flexDirection: "row",
    alignItems: "center",
    gap: 15,
  },
});
