import { Ionicons } from "@expo/vector-icons";
import { useRouter } from "expo-router";
import { StyleSheet, Text, TouchableOpacity, View } from "react-native";
import { useLanguage } from "../contexts/LanguageContext";

export default function Sidebar() {
  const router = useRouter();
  const { isRTL } = useLanguage();

  const menus = [
    {
      title: isRTL ? "الرئيسية" : "Dashboard",
      icon: "home",
      route: "/(main)/dashboard",
    },
    {
      title: isRTL ? "العملاء" : "Customers",
      icon: "people",
      route: "/(main)/customers",
    },
    {
      title: isRTL ? "الأصناف" : "Inventory",
      icon: "cube",
      route: "/(main)/inventory",
    },
    {
      title: isRTL ? "التقارير" : "Reports",
      icon: "bar-chart",
      route: "/(main)/reports",
    },
    {
      title: isRTL ? "الإعدادات" : "Settings",
      icon: "settings",
      route: "/(main)/settings",
    },
  ];

  return (
    <View style={styles.container}>
      <Text style={[styles.logo, { textAlign: isRTL ? "right" : "left" }]}>
        {isRTL ? "نظام الحوكمة والامتثال" : "Governance & Compliance"}
      </Text>

      {menus.map((item, index) => (
        <TouchableOpacity
          key={index}
          style={[
            styles.menu,
            {
              flexDirection: isRTL ? "row-reverse" : "row",
            },
          ]}
          onPress={() => router.push(item.route)}
        >
          <Ionicons name={item.icon} size={22} color="#fff" />

          <Text
            style={[
              styles.text,
              {
                marginRight: isRTL ? 12 : 0,
                marginLeft: isRTL ? 0 : 12,
                textAlign: isRTL ? "right" : "left",
              },
            ]}
          >
            {item.title}
          </Text>
        </TouchableOpacity>
      ))}
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    paddingTop: 25,
    backgroundColor: "#0F172A",
  },

  logo: {
    color: "#fff",
    fontSize: 22,
    fontWeight: "bold",
    paddingHorizontal: 20,
    marginBottom: 25,
  },

  menu: {
    alignItems: "center",
    paddingVertical: 16,
    paddingHorizontal: 20,
  },

  text: {
    color: "#fff",
    fontSize: 16,
    fontWeight: "600",
  },
});
