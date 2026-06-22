import { useEffect, useState } from "react";
import { Pressable, StyleSheet, View, useWindowDimensions } from "react-native";

import { useLanguage } from "../contexts/LanguageContext";

import AppHeader from "./AppHeader";
import Sidebar from "./Sidebar";

export default function AppLayout({ children, title }) {
  const { isRTL } = useLanguage();

  const { width } = useWindowDimensions();

  const isDesktop = width >= 1024;

  const [sidebarVisible, setSidebarVisible] = useState(isDesktop);

  useEffect(() => {
    if (isDesktop) {
      setSidebarVisible(true);
    } else {
      setSidebarVisible(false);
    }
  }, [isDesktop]);

  const toggleSidebar = () => {
    setSidebarVisible((prev) => !prev);
  };

  return (
    <View
      style={[
        styles.container,
        {
          flexDirection: isRTL ? "row-reverse" : "row",
        },
      ]}
    >
      {/* Desktop Sidebar */}

      {isDesktop && sidebarVisible && (
        <View style={styles.desktopSidebar}>
          <Sidebar />
        </View>
      )}

      {/* Main Content */}

      <View style={styles.content}>
        <AppHeader title={title} toggleSidebar={toggleSidebar} />

        <View style={styles.pageContent}>{children}</View>
      </View>

      {/* Mobile Overlay */}

      {!isDesktop && sidebarVisible && (
        <>
          <Pressable
            style={styles.overlay}
            onPress={() => setSidebarVisible(false)}
          />

          <View
            style={[styles.mobileSidebar, isRTL ? { right: 0 } : { left: 0 }]}
          >
            <Sidebar />
          </View>
        </>
      )}
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    backgroundColor: "#F1F5F9",
  },

  desktopSidebar: {
    width: 280,
    backgroundColor: "#081A38",

    borderRightWidth: 1,
    borderRightColor: "#1E293B",

    shadowColor: "#000",
    shadowOpacity: 0.15,
    shadowRadius: 12,
    elevation: 8,
  },

  content: {
    flex: 1,
    backgroundColor: "#F8FAFC",
  },

  pageContent: {
    flex: 1,
    padding: 24,
  },

  overlay: {
    position: "absolute",

    top: 0,
    left: 0,
    right: 0,
    bottom: 0,

    backgroundColor: "rgba(0,0,0,0.4)",

    zIndex: 998,
  },

  mobileSidebar: {
    position: "absolute",

    top: 0,
    bottom: 0,

    width: 280,

    backgroundColor: "#081A38",

    zIndex: 999,

    shadowColor: "#000",
    shadowOpacity: 0.25,
    shadowRadius: 20,
    elevation: 15,
  },
});
