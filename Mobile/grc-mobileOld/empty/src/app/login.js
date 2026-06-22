import { useState } from "react";
import {
  Alert,
  Image,
  StyleSheet,
  Text,
  TextInput,
  TouchableOpacity,
  View,
} from "react-native";

import { router } from "expo-router";
import api from "../services/api";

export default function Login() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [loading, setLoading] = useState(false);

  const handleLogin = async () => {
    if (!username || !password) {
      Alert.alert("تنبيه", "أدخل اسم المستخدم وكلمة المرور");
      return;
    }

    setLoading(true);

    try {
      const response = await api.post("/api/auth/login", {
        username,
        password,
      });

      const data = response.data;

      if (data?.accessToken) {
        await AsyncStorage.setItem("token", data.accessToken);
        await AsyncStorage.setItem("refreshToken", data.refreshToken || "");

        router.replace("/main/dashboard");
      } else {
        Alert.alert("خطأ", data?.message || "فشل تسجيل الدخول");
      }
    } catch (error) {
      const msg =
        error?.response?.data?.message || error?.message || "فشل تسجيل الدخول";

      Alert.alert("خطأ", msg);
    } finally {
      setLoading(false);
    }
  };

  return (
    <View style={styles.container}>
      <Image
        source={require("../../assets/images/logo.png")}
        resizeMode="contain"
        style={{
          width: 120,
          height: 120,
        }}
      />

      <Text style={styles.title}>نظام الحوكمة والامتثال</Text>
      <TextInput
        style={styles.input}
        placeholder="اسم المستخدم"
        value={username}
        onChangeText={setUsername}
        placeholderTextColor="#999"
        editable={!loading}
      />
      <TextInput
        style={styles.input}
        placeholder="كلمة المرور"
        secureTextEntry
        value={password}
        onChangeText={setPassword}
        placeholderTextColor="#999"
        editable={!loading}
      />
      <TouchableOpacity
        style={styles.button}
        onPress={handleLogin}
        disabled={loading}
      >
        <Text style={styles.buttonText}>
          {loading ? "جاري التحميل..." : "تسجيل الدخول"}
        </Text>
      </TouchableOpacity>
      <TouchableOpacity
        style={styles.registerButton}
        onPress={() => router.push("main/register")}
      >
        <Text style={styles.registerText}>إنشاء حساب جديد</Text>
      </TouchableOpacity>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: "center",
    padding: 25,
    backgroundColor: "#fff",
  },

  logo: {
    width: 120,
    height: 120,
    alignSelf: "center",
    marginBottom: 20,
    resizeMode: "contain",
  },

  title: {
    fontSize: 28,
    fontWeight: "bold",
    marginBottom: 30,
    textAlign: "center",
    color: "#1976d2",
  },

  input: {
    borderWidth: 1,
    borderColor: "#ddd",
    padding: 15,
    marginBottom: 15,
    borderRadius: 8,
    fontSize: 16,
  },

  button: {
    backgroundColor: "#1976d2",
    padding: 15,
    borderRadius: 8,
    alignItems: "center",
  },

  buttonText: {
    color: "#fff",
    fontSize: 16,
    fontWeight: "bold",
  },

  registerButton: {
    marginTop: 20,
    alignItems: "center",
  },

  registerText: {
    color: "#1976d2",
    fontSize: 16,
    fontWeight: "bold",
  },
});
