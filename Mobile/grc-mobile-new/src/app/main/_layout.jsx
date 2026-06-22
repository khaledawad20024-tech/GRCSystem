import { Slot } from "expo-router";
import AppLayout from "../../components/AppLayout";

export default function RootLayout() {
  return (
    <AppLayout title="نظام الحوكمة والامتثال">
      <Slot />
    </AppLayout>
  );
}
