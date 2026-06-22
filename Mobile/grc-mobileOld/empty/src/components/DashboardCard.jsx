import { StyleSheet, Text, TouchableOpacity } from "react-native";

import { Ionicons } from "@expo/vector-icons";

export default function DashboardCard({ title, icon, color, onPress }) {
  return (
    <TouchableOpacity style={styles.card} onPress={onPress}>
      <Ionicons name={icon} size={42} color={color} />

      <Text style={styles.title}>{title}</Text>
    </TouchableOpacity>
  );
}

const styles = StyleSheet.create({
  card: {
    flex: 1,

    margin: 10,

    minHeight: 130,

    borderRadius: 12,

    backgroundColor: "#fff",

    justifyContent: "center",

    alignItems: "center",

    elevation: 3,
  },

  title: {
    marginTop: 10,

    fontSize: 15,

    textAlign: "center",
  },
});
