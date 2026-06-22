import { useState } from "react";
import { StyleSheet, useWindowDimensions, View } from "react-native";

import AppHeader from "./AppHeader";
import Sidebar from "./Sidebar";

export default function AppLayout({ children, title }) {
  const [sidebarVisible, setSidebarVisible] = useState(true);

  const { width } = useWindowDimensions();

  const isDesktop = width >= 1024;

  return (
    <View style={styles.container}>
      {isDesktop && sidebarVisible && (
        <View style={styles.sidebar}>
          <Sidebar />
        </View>
      )}

      <View style={styles.content}>
        <AppHeader
          title={title}
          sidebarVisible={sidebarVisible}
          setSidebarVisible={setSidebarVisible}
        />

        {children}
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    flexDirection: "row",
  },

  sidebar: {
    width: 260,
    backgroundColor: "#0056A6",
  },

  content: {
    flex: 1,
    backgroundColor: "#F5F5F5",
  },
});
