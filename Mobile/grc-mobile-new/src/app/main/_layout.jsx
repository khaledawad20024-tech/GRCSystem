import { Slot } from "expo-router";
import AppLayout from "../../components/AppLayout";
import { useLanguage } from "../../contexts/LanguageContext";

export default function MainLayout() {
  const { language } = useLanguage();

  return (
    <AppLayout
      title={language === "ar" ? "نظام الحوكمة والامتثال" : "GRC System"}
    >
      <Slot />
    </AppLayout>
  );
}
