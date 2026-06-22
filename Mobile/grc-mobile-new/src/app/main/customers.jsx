import { StyleSheet, Text, View } from "react-native";
import AppLayout from "../../components/AppLayout";

export default function Customers() {
  const { isRTL, setIsRTL } = useLanguage();
  setIsRTL(!isRTL);
  return (
    <AppLayout title="العملاء">
      <View style={styles.container}>
        <Text style={styles.title}>إدارة العملاء</Text>
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
