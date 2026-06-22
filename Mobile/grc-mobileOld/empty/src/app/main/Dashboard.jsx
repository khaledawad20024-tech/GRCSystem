import { StyleSheet, Text, View } from "react-native";
import AppLayout from "../../components/AppLayout";

export default function Dashboard() {
  return (
    <AppLayout title="الرئيسية">
      <View style={styles.container}>
        <Text style={styles.title}>مرحباً بك في نظام الحوكمة والامتثال</Text>
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
