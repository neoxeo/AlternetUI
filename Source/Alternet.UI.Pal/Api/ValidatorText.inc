// <auto-generated> DO NOT MODIFY MANUALLY. Copyright (c) 2025 AlterNET Software.</auto-generated>

public:
static void DeleteValidatorText(void* handle);
static void* CreateValidatorText(int64_t style);
static int64_t GetStyle(void* handle);
static void SetStyle(void* handle, int64_t style);
static void SetCharIncludes(void* handle, const string& chars);
static void AddCharIncludes(void* handle, const string& chars);
static string GetCharIncludes(void* handle);
static void AddInclude(void* handle, const string& include);
static void AddExclude(void* handle, const string& exclude);
static void SetCharExcludes(void* handle, const string& chars);
static void AddCharExcludes(void* handle, const string& chars);
static string GetCharExcludes(void* handle);
static void ClearExcludes(void* handle);
static void ClearIncludes(void* handle);
static string IsValid(void* handle, const string& val);

public:
ValidatorText();

protected:
virtual ~ValidatorText();

private:
BYREF_ONLY(ValidatorText);
