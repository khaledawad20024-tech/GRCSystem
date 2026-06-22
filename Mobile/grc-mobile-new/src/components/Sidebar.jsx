import { StyleSheet, Text, TouchableOpacity, View } from "react-native";

import { useRouter } from "expo-router";

import { Ionicons } from "@expo/vector-icons";

export default function Sidebar() {
  const router = useRouter();

  const menus = [
    {
      title: "الرئيسية",
      icon: "home",
      route: "/(main)/dashboard",
    },

    {
      title: "العملاء",
      icon: "people",
      route: "/(main)/customers",
    },

    {
      title: "الأصناف",
      icon: "cube",
      route: "/(main)/inventory",
    },

    {
      title: "التقارير",
      icon: "bar-chart",
      route: "/(main)/reports",
    },

    {
      title: "الإعدادات",
      icon: "settings",
      route: "/(main)/settings",
    },
  ];

  return (
    <View style={styles.container}>
      <Text style={styles.logo}>GRC System</Text>

      {menus.map((item, index) => (
        <TouchableOpacity
          key={index}
          style={styles.menu}
          onPress={() => router.push(item.route)}
        >
          <Ionicons name={item.icon} size={22} color="#fff" />

          <Text style={styles.text}>{item.title}</Text>
        </TouchableOpacity>
      ))}
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: 30,
  },

  logo: {
    color: "#fff",
    textAlign: "center",

    fontSize: 24,

    fontWeight: "bold",

    marginBottom: 30,
  },

  menu: {
    flexDirection: "row",

    alignItems: "center",

    padding: 15,
  },

  text: {
    color: "#fff",

    marginLeft: 10,

    fontSize: 16,
  },
});
