import { Ionicons } from "@expo/vector-icons";
import { StyleSheet, Text, TouchableOpacity } from "react-native";

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
    backgroundColor: "#FFFFFF",
    borderRadius: 16,
    padding: 24,
    elevation: 2,
    justifyContent: "center",
    alignItems: "center",
  },

  title: {
    marginTop: 10,
    fontSize: 15,
    textAlign: "center",
  },
});
