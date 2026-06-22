import { StyleSheet, View } from "react-native";

import { router } from "expo-router";
import DashboardCard from "../../components/DashboardCard";

export default function Dashboard() {
  return (
    //<AppLayout title="الرئيسية">
    <View style={styles.container}>
      <View style={styles.row}>
        <DashboardCard
          title="الوزراء"
          icon="people"
          color="#1976d2"
          onPress={() => router.push("/ministers")}
        />

        <DashboardCard
          title="أعضاء مجلس الأمة"
          icon="business"
          color="#388e3c"
          onPress={() => router.push("/members")}
        />
      </View>

      <View style={styles.row}>
        <DashboardCard
          title="المسحوبة جنسياتهم"
          icon="warning"
          color="#f57c00"
          onPress={() => router.push("/nationality")}
        />

        <DashboardCard
          title="التقارير"
          icon="bar-chart"
          color="#7b1fa2"
          onPress={() => router.push("/reports")}
        />
      </View>

      <View style={styles.row}>
        <DashboardCard
          title="إدارة المستخدمين"
          icon="person-add"
          color="#d32f2f"
          onPress={() => router.push("/users")}
        />

        <DashboardCard
          title="الإعدادات"
          icon="settings"
          color="#455a64"
          onPress={() => router.push("/settings")}
        />
      </View>
    </View>
    //</AppLayout>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    padding: 10,
  },

  row: {
    flexDirection: "row",
    justifyContent: "space-between",
  },
});
