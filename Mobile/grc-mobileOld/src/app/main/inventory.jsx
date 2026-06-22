import { StyleSheet, Text, View } from "react-native";
import AppLayout from "../../components/AppLayout";

export default function Inventory() {
  return (
    <AppLayout title="الأصناف">
      <View style={styles.container}>
        <Text style={styles.title}>إدارة الأصناف</Text>
      </View>
    </AppLayout>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 20,
  },

  title: {
    fontSize: 24,
    fontWeight: "bold",
  },
});
