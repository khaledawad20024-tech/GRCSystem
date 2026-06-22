import { createContext, useContext, useState } from "react";

const LanguageContext = createContext(null);

const translations = {
  ar: {
    dashboard: "الرئيسية",
    customers: "العملاء",
    inventory: "الأصناف",
    reports: "التقارير",
    settings: "الإعدادات",
    login: "تسجيل الدخول",
  },

  en: {
    dashboard: "Dashboard",
    customers: "Customers",
    inventory: "Inventory",
    reports: "Reports",
    settings: "Settings",
    login: "Login",
  },
};

export function LanguageProvider({ children }) {
  const [language, setLanguage] = useState("ar");

  const isRTL = language === "ar";

  const toggleLanguage = () => {
    setLanguage((prev) => (prev === "ar" ? "en" : "ar"));
  };

  const t = (key) => {
    return translations[language]?.[key] || key;
  };

  return (
    <LanguageContext.Provider
      value={{
        language,
        setLanguage,
        isRTL,
        toggleLanguage,
        t,
      }}
    >
      {children}
    </LanguageContext.Provider>
  );
}

export function useLanguage() {
  return useContext(LanguageContext);
}
